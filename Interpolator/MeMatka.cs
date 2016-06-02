using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using System.Globalization;
using System.Threading;
using System.Data.OleDb;
using System.Data;

namespace Interpolator
{
    public class mematka
    {
        //0-poly
        //1-sin
        double dif;
        public tocke[] izrac_func(tocke[] temp, int mode, int n)
        {
            if (n == 0) return null;
            tocke[] rje = new tocke[n];
            double[][] matrica = new double[n - 1][];
            tocke nul = new tocke();
            #region sort
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (temp[j].x < temp[i].x)
                    {
                        tocke tmp = temp[i];
                        temp[i] = temp[j];
                        temp[j] = tmp;
                    }
                }
            }
            #endregion
            #region odabir
            if (mode == 0)
            {
                for (int i=0;i< n; i++)
                {
                    if (temp[i].x == 0)
                    {
                        tocke tm = temp[i];
                        temp[i] = temp[n-1];
                        temp[n-1] = tm;
                        break;
                    }
                }
                #region init_matrix
                matrica = new double[n][];
                for (int j = 0; j < n; j++)
                {
                    double[] temp_red = new double[n + 1];
                    temp_red[n] = temp[j].y;
                    for (int i = 0; i < n; i++)
                    {
                        temp_red[n - 1 - i] = Math.Pow(temp[j].x, i);
                    }
                    matrica[j] = temp_red;
                }
                #endregion
            }
            dif = (MathHelper.TwoPi) / ((temp[n - 1].x - temp[0].x));
            if (mode == 1)
            {
                if (n == 1)
                {
                    tocke[] r = new tocke[1];
                    r[0].y = temp[0].y;
                    r[0].x = 0;
                    return r;
                }
                #region init_matrix

                for (int j = 0; j < (n - 1); j++)
                {
                    double[] temp_red = new double[n];
                    temp_red[n - 1] = temp[j].y;
                    temp_red[0] = 1;
                    for (int i = 1; i < (n - 1); i++)
                    {
                        temp_red[i] = Math.Sin(temp[j].x * (i * dif));
                    }
                    matrica[j] = temp_red;
                }
                #endregion
            }
            #endregion
            #region prema_dole
            for (int i = 0; i < (n - mode); i++)
            {
                for (int j = i + 1; j < (n - mode); j++)
                {
                    double koeficjent = matrica[j][i] / matrica[i][i];
                    //matrica[j][i] = 0;

                    for (int k = 0; k < (n+1-mode); k++)
                    {
                        matrica[j][k] = matrica[j][k] - (koeficjent * matrica[i][k]);
                    }
                }
            }

            #endregion
            #region prema_gore
            for (int i = n - 1 - mode; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    double koeficjent = new double();
                    koeficjent = matrica[j][i] / matrica[i][i];
                    matrica[j][i] = 0;
                    matrica[j][n - mode] = matrica[j][n - mode] - koeficjent * matrica[i][n - mode];

                }
            }
            #endregion
            #region make_rj
            if (mode == 1)
            {
                for (int i = 0; i < (n - 1); i++)
                {
                    double broj = matrica[i][n - 1] / matrica[i][i];
                    rje[i].x = dif * (i);
                    rje[i].y = broj;
                }
            }else if (mode == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    double broj = matrica[i][n] / matrica[i][i];
                    rje[i].x = (n-1-i);
                    rje[i].y = broj;
                }

            }
            #endregion


            return rje;
        }
        public string string_func(tocke[] temp, int mode, Postavke p)
        {
            if (temp == null) return "f(x)=NULL";
            Thread.CurrentThread.CurrentCulture = new CultureInfo("hr-HR");
            StringBuilder temp_string = new StringBuilder();
            temp_string.Append("f(X)=");
            string rje = "";
            #region sine
            if (mode == 1)
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    double broj = Math.Round(temp[i].y, p.BrojDecimala);
                    if (broj != 0)
                    {

                        if (broj > 0 && i > 0)
                        {
                            temp_string.Append("+");
                        }
                        temp_string.Append(broj);
                        if (i > 0)
                            temp_string.Append("sin(");
                        if (dif == Double.PositiveInfinity)
                            dif = 0;
                        if (dif * i != 1 && dif * i != 0)
                        {
                            temp_string.Append(Math.Round(dif * i, p.BrojDecimala));
                        }
                        if (i > 0)
                            temp_string.Append("X) ");
                    }
                }
                rje = temp_string.ToString();
            }
            #endregion
            #region poly
            string expontent = "⁰¹²³⁴⁵⁶⁷⁸⁹⁺⁻⁼⁽⁾";
            if (mode == 0)
            {
                for (int i = 0; i < temp.Length; i++)
                {


                    double broj = Math.Round(temp[i].y, p.BrojDecimala);
                    if (broj != 0)
                    {
                        if (broj > 0 && i> 0)
                        {
                            temp_string.Append("+");
                        }
                        temp_string.Append(broj);
                        if (temp[i].x > 0)
                        {
                            temp_string.Append("X");
                            if (temp[i].x > 1)
                            {
                                string tmp = temp[i].x .ToString();
                                for (int ii = 0; ii < tmp.Length; ii++)
                                {
                                    int index = Convert.ToInt32(tmp.Substring(ii,1));
                                    temp_string.Append(expontent[index]);
                                }
                            }
                        }
                    }
                }
                rje = temp_string.ToString();
            }
            #endregion
            return rje;
        }

    }
}
