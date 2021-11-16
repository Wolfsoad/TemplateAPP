using FluentValidation;
using STRACT.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STRACT.Data.Validators
{
    public class UsersSkillsEvaluationsValidator : AbstractValidator<UserSkillsEvaluation>
    {
        public UsersSkillsEvaluationsValidator()
        {
            RuleFor(us => us.SkillScore)
                .ExclusiveBetween(0, 5);
        }
    }
}
