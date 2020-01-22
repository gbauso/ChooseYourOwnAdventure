using System;
using System.Collections.Generic;
using System.Text;

namespace ChooseYourOwnAdventure.Infrastructure
{
    public interface IFactory<T>
    {
        T GetInstance();
    }
}
