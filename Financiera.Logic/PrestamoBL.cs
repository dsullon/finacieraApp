using Financiera.Data;
using Financiera.Dominio;
using System;
using System.Collections.Generic;

namespace Financiera.Logic
{
    public static class PrestamoBL
    {
        public static bool Insertar(Prestamo prestamo)
        {
            prestamo.Fecha = DateTime.Today;
            int cuotas = prestamo.Plazo;
            decimal importeCuota = prestamo.Importe / cuotas;
            DateTime fechaInicio = prestamo.FechaDeposito;
            int cuota = 1;
            DateTime fechaVencimiento;
            var detalles = new List<DetallePrestamo>();
            DetallePrestamo detallePrestamo;
            while(cuota <= cuotas)
            {
                decimal montoCuota = importeCuota + (importeCuota * prestamo.Tasa);
                fechaVencimiento = calcularVencimiento(fechaInicio);
                fechaInicio = fechaVencimiento;
                detallePrestamo = new DetallePrestamo();
                detallePrestamo.NumeroCuota = cuota;
                detallePrestamo.ImporteCuota = montoCuota;
                detallePrestamo.FechaVencimiento = fechaVencimiento;
                detalles.Add(detallePrestamo);
                cuota++;
            }

            var prestamoData = new PrestamoData();
            prestamoData.Insertar(prestamo, detalles);
            return true;
        }

        public static bool Actualizar(Prestamo prestamo)
        {
            return true;
        }

        private static DateTime calcularVencimiento(DateTime fecha)
        {
            if(fecha.Day != DateTime.DaysInMonth(fecha.Year, fecha.Month))
            {
                return fecha.AddMonths(1);
            } else
            {
                return fecha.AddDays(1).AddMonths(1).AddDays(-1);
            }
        }
    }
}
