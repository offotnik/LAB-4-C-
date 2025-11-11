using System;

namespace lab_3_6_7_
{
    class OverrideMet
    {
        private double _a;
        private double _b;
        private double _c;

        public OverrideMet(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        // Унарные операции
        public static OverrideMet operator ++(OverrideMet equation)
        {
            return new OverrideMet(equation._a + 1, equation._b + 1, equation._c + 1);
        }

        public static OverrideMet operator --(OverrideMet equation)
        {
            return new OverrideMet(equation._a - 1, equation._b - 1, equation._c - 1);
        }

        // Неявное приведение к double (дискриминант)
        public static implicit operator double(OverrideMet equation)
        {
            return equation._b * equation._b - 4 * equation._a * equation._c;
        }

        // Явное приведение к bool (существуют ли корни)
        public static explicit operator bool(OverrideMet equation)
        {
            double discriminant = equation._b * equation._b - 4 * equation._a * equation._c;
            return discriminant >= 0;
        }

        // Бинарные операции
        public static bool operator ==(OverrideMet eq1, OverrideMet eq2)
        {
            if (ReferenceEquals(eq1, eq2)) return true;
            if (eq1 is null || eq2 is null) return false;

            return eq1._a == eq2._a && eq1._b == eq2._b && eq1._c == eq2._c;
        }

        public static bool operator !=(OverrideMet eq1, OverrideMet eq2)
        {
            return !(eq1 == eq2);
        }


        // Метод для решения квадратного уравнения
        public static double[] QuadraticEquation(double a, double b, double c)
        {
            double[] result = new double[2];

            double discr = b * b - 4 * c * a;

            if (discr < 0)
            {
                return result;
            }
            else if (discr == 0)
            {
                result[0] = -b / (2 * a);
                return result;
            }
            else
            {
                double discrq = Math.Sqrt(discr);
                double x1 = (-b - discrq) / (2 * a);
                double x2 = (-b + discrq) / (2 * a);

                result[0] = x1;
                result[1] = x2;
                return result;
            }
        }

        // Для удобства вывода
        public override string ToString()
        {
            return $"{_a}x^2 + {_b}x + {_c} = 0";
        }
    }
}