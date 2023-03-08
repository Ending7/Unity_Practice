using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_TextRPG
{
    public enum PlayerType
    {

        none = 0,
        knight = 1,
        archer = 2,
        mage = 3
    }
    class Player : Creature
    {
        protected PlayerType m_type = PlayerType.none;
      

        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            m_type = type;
        }

        // 위에 변수들을 protected한 이유는 변수들을 가지고 다른 곳에서 함수를 만들거나, 함부로 접근하여 사용하지 못하도록 하기 위함.
        // 오로지 부모에서 함수를 만들어서 자식으로 상속하여 사용할 뿐임.
        // public으로 하는 이유는 다른 곳에서 '함수'로는 접근할 수 있도록 하기 위함.
      
        
        public PlayerType GetPlayerType() { return m_type; }
       

    }
    class Knight : Player
    {
        public Knight() : base(PlayerType.knight)
        {
            SetInfo(100,10);
        }
    }

    class Archer : Player
    {
        public Archer() : base(PlayerType.archer)
        {
            SetInfo(75, 12);

        }

    }
    class Mage : Player
    {
        public Mage() : base(PlayerType.mage)
        {
            SetInfo(50, 15);
        }

    }
}
