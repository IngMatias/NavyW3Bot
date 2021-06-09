
    // S - SRP: Esta interface se encarga de la responsabilidad de definir cualquier tipo de lectura.
    // En el caso de querer agregar un nuevo metodo de lectura solo hace falta implementar esta interface y
    // realizar la invocacion correspondiente.

    // O - OCP: Se piensa la jerarquia IReader - Reader para permitir el agregado de nuevos
    // metodos de lectura sin la necesidad de alterar el codigo, sino mas bien agregandolo en una nueva clase.
    
    // L - LSP: Todos los subtipos de IPrinter deben implementar el metodo IReader, lo que hace que puedan
    // reibir el mensaje correspondiente en cualquier caso, aunque se comporten de manera distinta.
    // Se debe revisar cuidadosamente los efectos colaterales.

    // I - ISP: Todas las clases que dependan de IReader deberian usar ambas operaciones Read.

    // D - DIP: IReader no tiene dependencias, cumple DIP.

namespace Library
{
    public interface IReader
    {
        public string Read();
        public string Read(string msg);
    }
}