using System;

namespace InlineSingleton.MyWork
{
    public class Blackjack
    {
        private static HitStayResponse _hitStayResponse = new HitStayResponse();

        public void Play()
        {
            Player player = new Player();
            Dealer dealer = new Dealer();
            BufferedReader input = new BufferedReader();

            this.Deal();
            
            Console.WriteLine(player.GetHandAsString());
            
            Console.WriteLine(dealer.GetHandAsStringWithFirstCardDown());

            HitStayResponse hitStayResponse;

            do {
                Console.Write("H)it or S)tay: ");
                
                hitStayResponse = this.ObtainHitStayResponse(input);
                Console.Write(hitStayResponse.ToString());

                if (hitStayResponse.ShouldHit()) {
                    this.DealCardTo(player);
                    Console.WriteLine(player.GetHandAsString());
                }
            }
            while (this.CanPlayerHit(hitStayResponse));
        }

        public HitStayResponse ObtainHitStayResponse(BufferedReader input)
        {
            _hitStayResponse.ReadFrom(input);

            return _hitStayResponse;
        }

        public void SetPlayerResponse(HitStayResponse newHitStayResponse) 
        {
            _hitStayResponse = newHitStayResponse;
        }

        private Boolean CanPlayerHit(HitStayResponse hitStayResponse)
        {
            throw new NotImplementedException();
        }

        private void DealCardTo(Object player)
        {
            throw new NotImplementedException();
        }

        private void Deal()
        {
            throw new NotImplementedException();
        }
    }
}