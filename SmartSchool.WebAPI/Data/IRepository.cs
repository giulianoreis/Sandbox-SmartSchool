using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();

        //Alunos
        Aluno[] GetAllAlunos(bool includeProfessor=false);
        Aluno[] GetAllAlunosByDisciplinaId(int discliplinaId ,bool includeProfessor= false);
        Aluno GetAlunoById(int alunoid ,bool includeProfessor= false); 

        //professores
        Professor[] GetAllProfessores(bool includeAlunos = false );
        Professor[] GetAllProfessoresByDisciplinaId(int discliplinaId ,bool includeAlunos = false);
        Professor GetProfessorById(int professorid ,bool includeProfessor= false);
        



    }
}