namespace HelpPeople.Generic
{
    //Se le agresa sealed a la clase para que sea sellada y no pueda ser heredada, es decir que no se
    //puedan crear clases o subclases a partir de esta y no puedan o extender o modificar su comportamiento

    // Se le agrega la declaración <T> al final para que la clase sea genérica y  pueda trabajar con diferentes
    // tipos de datos, es decir ya que está es la clase con la que se van a devolver todas las respuestas de la api,
    // permita mesclarse con diferentes tipos de datos en sus atributos.
    public sealed class RequestResult<T>
    {
        public RequestResult()
        {
            // Inicializa las propiedades por default
            IsSuccess = false;
            IsError = true;
            SuccesMessage = string.Empty;
            ErrorMessage = string.Empty;
            Result = default(T);
        }

        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public string SuccesMessage { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }

        //Se crea el método estático para que pueda ser accedido a travez de la clase, sin necesidad de crear una instancia
        public static RequestResult<T> CreateError(string errorMessage)
        {
            return new RequestResult<T>
            {
                IsSuccess = false,
                IsError = true,
                ErrorMessage = errorMessage
            };
        }
        public static RequestResult<T> CreateSuccesful(T result, string? succesMessage = null)
        {
            return new RequestResult<T>
            {
                IsSuccess = true,
                IsError = false,
                SuccesMessage = succesMessage,
                Result = result
            };
        }
    }
}
