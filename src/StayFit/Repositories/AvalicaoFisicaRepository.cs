using StayFit.Context;
using StayFit.Models;
using StayFit.Repositories.Interfaces;

namespace StayFit.Repositories
{
    public class AvalicaoFisicaRepository:IAvalicaoFisicaRepository
    {
        private readonly AppDbContext _context;

        public AvalicaoFisicaRepository(AppDbContext context)
        {
            _context = context;
        }


        public Avaliacao GetAvaliacao(int avaliacaoId)
        {
            return _context.Avaliacoes.FirstOrDefault(av => av.AvaliacaoId == avaliacaoId);
        }

        public Avaliacao Create(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            _context.SaveChanges();
            return avaliacao;
        }

        public Avaliacao UpdateAnamnese(Avaliacao avaliacao)
        {
            Avaliacao av = GetAvaliacao(1);
           

            av.Peso = avaliacao.Peso;
            av.Altura = avaliacao.Altura;
            av.IsDeficiente = avaliacao.IsDeficiente;
            av.IsPraticante = avaliacao.IsPraticante;
            av.Observacoes = av.Observacoes;
            av.IsFumante = avaliacao.IsFumante;
            av.IsProblemaSaude = avaliacao.IsProblemaSaude;
            av.ProblemaSaude = avaliacao.ProblemaSaude;
            av.IsTomaMedicamentos = avaliacao.IsTomaMedicamentos;
            av.Medicamentos = avaliacao.Medicamentos;
            av.Objetivos = avaliacao.Objetivos;
            av.Deficiencia = avaliacao.Deficiencia;

            _context.Avaliacoes.Update(av);
            _context.SaveChanges();

            System.Diagnostics.Debug.WriteLine("----------- " + av.Peso);

            return av;
        }
    }
}
