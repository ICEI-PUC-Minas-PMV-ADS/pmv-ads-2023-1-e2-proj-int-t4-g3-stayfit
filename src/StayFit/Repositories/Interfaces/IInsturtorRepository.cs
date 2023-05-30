using Microsoft.EntityFrameworkCore;
using StayFit.Context;
using StayFit.Models;

namespace StayFit.Repositories.Interfaces
{
    public interface IInsturtorRepository
    {
        public Instrutor Create(Instrutor instrutor);
        public Instrutor GetInstrutorByCPF(string cpf);
    }
}
