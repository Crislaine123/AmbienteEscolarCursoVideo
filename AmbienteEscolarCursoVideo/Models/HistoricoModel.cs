namespace AmbienteEscolarCursoVideo.Models
{
    public class HistoricoModel
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public AlunoModel Aluno { get; set; }

        public int MateriaId { get; set; }
        public MateriaModel Materia { get; set; }

        public double Nota1 { get; set; }
        public double Nota2{ get; set; }
        public double Nota3 { get; set; }
        public double Nota4 { get; set; }

        public double Media { get; set; }
    }
}
