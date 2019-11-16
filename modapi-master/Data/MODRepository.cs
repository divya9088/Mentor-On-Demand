using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorOnDemand.Dto;
using MentorOnDemand.Models;

namespace MentorOnDemand.Data
{
    public class MODRepository : IRepository
    {
        MentorContext context;
        public MODRepository(MentorContext context)
        {
            this.context = context;
        }

        public bool AddCourse(CourseDto courseDto)
        {
            throw new NotImplementedException();
        }

        public bool AddPayment(PaymentDtls payment)
        {

            try
            {
                context.PaymentDtls.Add(payment);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AddSkill(Skill skill)
        {

            try
            {
                context.Skills.Add(skill);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool AddTraining(TrainingDtls training)
        {
            try
            {
                context.TrainingDtls.Add(training);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool BlockUser(string id)
        {
            {
                var userblock = context.UserMods.SingleOrDefault(u => u.Id == id);
                userblock.Active = !userblock.Active ;
            }
            var result = context.SaveChanges();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteSkill(Skill skill)
        {
            try
            {
                context.Skills.Remove(skill);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PaymentDtls GetPaymentById(int id)
        {
            return context.PaymentDtls.Find(id);
        }

        public List<PaymentDtls> GetPayments()
        {
            return context.PaymentDtls.ToList();
        }

        public List<UserProfileDto> GetSearchData(string trainertechnology)
        {
            var search = from u in context.UserMods
                          where u.TrainerTechnology == trainertechnology
                          select new UserProfileDto
                          {
                              Id = u.Id,
                              Email=u.Email,
                              Firstname = u.Firstname,
                              Lastname = u.Lastname,
                              YearOfExperience = u.YearOfExperience,
                              TrainerTechnology = u.TrainerTechnology
                          };
            return search.ToList();
        }

        public Skill GetSkill(int id)
        {
            return context.Skills.Find(id);
        }

        public IEnumerable<Skill> GetSkills()
        {
            return context.Skills.ToList();
        }

        public TrainingDtls GetTrainingById(int id)
        {
            return context.TrainingDtls.Find(id);

        }

        public List<TrainingDtls> GetTrainings()
        {
            return context.TrainingDtls.ToList();
        }

        public UserProfileDto GetUser(string id)
        {
            var profile = from u in context.UserMods
                          where u.Id == id
                          select new UserProfileDto
                          {
                              Id=u.Id,
                              Email = u.Email,
                              Username = u.UserName,
                              Firstname = u.Firstname,
                              Lastname = u.Lastname,
                              YearOfExperience = u.YearOfExperience,
                              TrainerTechnology = u.TrainerTechnology,
                              Contactnumber = u.PhoneNumber
                          };
            return profile.FirstOrDefault();
        }

        //public IEnumerable<UserMod> GetUsers()
        //{
        //    return context.UserMods.ToList();
        //}

        //public IEnumerable<string> GetUsers()
        //{
        //    var users = from u in context.UserMods
        //                join r in context.UserRoles on u.Id equals r.UserId
        //                select r.RoleId;
        //    return users;
        //}

        public List<UserDto> GetUsers()
        {
            var users = (from u in context.UserMods
                         join r in context.UserRoles on u.Id equals r.UserId
                         select new UserDto
                         {
                             Id=u.Id,
                             Email = u.Email,
                             Firstname = u.Firstname,
                             Lastname = u.Lastname,
                             Role = r.RoleId,
                             Active = u.Active
                         });
            return users.ToList();
        }

        public void PutAcceptRequest(int id)
        {
            var training = context.TrainingDtls.Find(id);
            training.accept = true;
            context.TrainingDtls.Update(training);
            context.SaveChanges();
        }

        public void PutRejectrequest(int id)
        {
            var reject = context.TrainingDtls.Find(id);
            reject.rejectNotify = true;
            context.TrainingDtls.Update(reject);
            context.SaveChanges();
        }

        public void PutupdatePaymentAndCommisionById(string id, PaymentDto payment)
        {
            var paymentCommision = context.PaymentDtls.Find(payment.id);
            paymentCommision.commision = payment.commision;
            paymentCommision.trainerFees = payment.trainerFees;
            context.PaymentDtls.Update(paymentCommision);
            context.SaveChanges();
        }

        public void PutupdateTrainingAndPaymentStatusbyId(int id)
        {
            var payment = context.TrainingDtls.Find(id);
            payment.trainingPaymentStatus = true;
            context.TrainingDtls.Update(payment);
            context.SaveChanges();
        }



        public void PutupdateTrainingProgressById(int id, int progressValue)
        {
            var progressbyId = context.TrainingDtls.Find(id);
            progressbyId.progress= progressValue;
            if(progressValue==100)
            {
                progressbyId.status = "completed";
            }
            context.TrainingDtls.Update(progressbyId);
            context.SaveChanges();
        }

        public void PutupdateTrainingRatingById(int id, int rating)
        {
            var ratings = context.TrainingDtls.Find(id);
            ratings.rating = rating;
            context.TrainingDtls.Update(ratings);
            context.SaveChanges();
        }

        public void PutupdateTrainingStatusById(int id)
        {
            var trainingstatus = context.TrainingDtls.Find(id);
            trainingstatus.status = "Current";
            trainingstatus.progress = 0;
            context.TrainingDtls.Update(trainingstatus);
            context.SaveChanges();
        }

        public bool UpdateUser(string id,UserProfileDto userProfileDto)
        {
            try
            {
                var user = context.UserMods.Find(userProfileDto.Id);
                user.Firstname = userProfileDto.Firstname;
                user.Lastname = userProfileDto.Lastname;
                user.Email = userProfileDto.Email;
                user.PhoneNumber = userProfileDto.Contactnumber;
                user.YearOfExperience = userProfileDto.YearOfExperience;

                context.UserMods.Update(user);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //public bool UpdateActor(UserProfileDto user)
        //{
        //    try
        //    {
        //        context.UserMods.Update(user);
        //        int result = context.SaveChanges();
        //        if (result > 0)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        //public IEnumerable<string> GetUsers(int roleId)
        //{
        //    var users = from u in context.UserMods
        //                join r in context.UserRoles on u.Id equals r.UserId
        //                where r.RoleId == roleId.ToString()
        //                select u.Email;

        //    return users;                        
        //}
    }
}
