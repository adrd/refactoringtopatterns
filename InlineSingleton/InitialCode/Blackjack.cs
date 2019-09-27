using System;

namespace InlineSingleton.InitialCode
{
    public class Blackjack
    {
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
                
                hitStayResponse = ConsoleReader.ObtainHitStayResponse(input);
                Console.Write(hitStayResponse.ToString());

                if (hitStayResponse.ShouldHit()) {
                    this.DealCardTo(player);
                    Console.WriteLine(player.GetHandAsString());
                }
            }
            while (this.CanPlayerHit(hitStayResponse));
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