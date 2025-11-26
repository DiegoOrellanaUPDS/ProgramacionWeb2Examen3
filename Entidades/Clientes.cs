namespace ExamenFinalProgramacionWeb2.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CI { get; set; }
        public string Categoria { get; set; }
        public string Estado { get; set; } = "Activo";
    }

}
