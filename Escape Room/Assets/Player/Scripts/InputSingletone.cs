public static class InputSingletone
{
    private static PlayerInputMap _instance;

    public static PlayerInputMap Instance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerInputMap();
            }
            return _instance;
        }
    }
}
