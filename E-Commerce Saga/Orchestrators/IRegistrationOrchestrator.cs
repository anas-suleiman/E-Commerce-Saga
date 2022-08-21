using E_Commerce_Saga.Models;

namespace E_Commerce_Saga.Orchestrators
{
    public interface IRegistrationOrchestrator
    {
        Task<bool> Createregistration(RegistrationModel registrationModel);
    }
}