using System;

namespace ChooseYourOwnAdventure.Domain.Model
{
    public interface IDomain
    {
        void Validate(params bool[] properties);
    }
}
