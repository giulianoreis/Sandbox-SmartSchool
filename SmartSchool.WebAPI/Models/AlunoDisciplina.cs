namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        {
        }

        public AlunoDisciplina(int alunoId, int disciplinaID)
        {
            this.AlunoId = alunoId;
           
            this.DisciplinaID = disciplinaID;


        }
        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }

        public int DisciplinaID { get; set; }

        public Disciplina Disciplina { get; set; }

    }
}