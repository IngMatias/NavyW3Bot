
    // S - SRP: Esta interface se encarga de la responsabilidad de definir cualquier tipo de impresion.
    // En el caso de querer agregar una nueva forma de impresion solo hace falta implementar esta interface y
    // realizar la invocacion correspondiente.

    // O - OCP: Se piensa la jerarquia IPrinter - Printer para permitir el agregado de nuevos
    // metodos de impresion sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: Todos los subtipos de IPrinter deben implementar el metodo Print, lo que hace que puedan
    // reibir el mensaje correspondiente en cualquier caso, aunque se comporten de manera distinta.
    // Se debe revisar cuidadosamente los efectos colaterales.

    // I - ISP: Todas las clases que dependan de IPrinter deberian usar la operacion Print.

    // D - DIP: IPrinter no tiene dependencias, cumple DIP.

    // Expert : En esta clase no se conoce.

    // Polimorfismo : El metodo Print es polimorfico en todos los IPrinter.

    // Creator : No se usa Creator.

namespace Library
{
    public interface IPrinter
    {
        public void Print(object ToPrint);
    }
}