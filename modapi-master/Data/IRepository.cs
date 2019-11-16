using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorOnDemand.Dto;
using MentorOnDemand.Models;

namespace MentorOnDemand.Data
{
    public interface IRepository
    {
        bool AddCourse(CourseDto courseDto);
        bool AddSkill(Skill skill);
        IEnumerable<Skill> GetSkills();
        Skill GetSkill(int id);
        bool DeleteSkill(Skill skill);
        UserProfileDto GetUser(string id);
        // IEnumerable<UserListDto> GetUsers();
        List<UserDto> GetUsers();
        bool BlockUser(string id);
        // bool UpdateActor(UserProfileDto user);
        bool UpdateUser(string Id,UserProfileDto userProfileDto);
        List<UserProfileDto> GetSearchData(string trainertechnology);
        bool AddTraining(TrainingDtls training);
        List<TrainingDtls> GetTrainings();
        void PutAcceptRequest(int id);
        TrainingDtls GetTrainingById(int id);
        bool AddPayment(PaymentDtls payment);
        void PutupdateTrainingAndPaymentStatusbyId(int id);
        List<PaymentDtls> GetPayments();
        void PutupdateTrainingStatusById(int id);
        PaymentDtls GetPaymentById(int id);
        void PutupdatePaymentAndCommisionById(string id, PaymentDto payment);
        void PutupdateTrainingProgressById(int id, int progressValue);
        void PutupdateTrainingRatingById(int id, int rating);
        void PutRejectrequest(int id);
    }
}
