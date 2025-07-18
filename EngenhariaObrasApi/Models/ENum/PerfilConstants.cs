namespace EngenhariaObrasApi.Models.Enums
{
    public static class PerfilConstants
    {
        public const string Administrador = "Administrador";
        public const string Gerente = "Gerente";
        public const string Engenheiro = "Engenheiro";
        public const string Cliente = "Cliente";
        public const string Visitante = "Visitante";

        public static List<string> TodosPerfis()
        {
            return new List<string>
            {
                Administrador,
                Gerente,
                Engenheiro,
                Cliente,
                Visitante
            };
        }
    }
}
