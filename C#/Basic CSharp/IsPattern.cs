using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_CSharp
{
    public class IsPattern
    {
        public IsPattern()
        {
            IAttackable attackable = new Player();

            if(attackable is Player)
            {
                Console.WriteLine("Is player !");
            }

            if (attackable.GetType() == typeof(Player))
            {
                Console.WriteLine("Is player !");
            }

            IAttackable attackable1 = new Player();

            switch (attackable1)
            {
                default:
                    break;

                case Player player when player.health > 50:
                    Console.WriteLine("Health 50");
                    break;
            }
        }
    }

    public class Player : IAttackable
    {
        public int health;
    }

    public interface IAttackable
    {

    }
}
