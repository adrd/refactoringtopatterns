namespace InlineSingleton.InitialCode
{
    public class ConsoleReader
    {
        private static HitStayResponse _hitStayResponse = new HitStayResponse();

        public static HitStayResponse ObtainHitStayResponse(BufferedReader input)
        {
            _hitStayResponse.ReadFrom(input);

            return _hitStayResponse;
        }

        public static void SetPlayerResponse(HitStayResponse newHitStayResponse)
        {
            _hitStayResponse = newHitStayResponse;
        }
    }
}
   
