namespace Fighters.Extensions
{
    public static class ConsoleUserInputExtensions
    {
        public static T ReadEnum<T>( Action onInput, Action onError ) where T : struct
        {
            bool isParsed = false;

            T result = default;

            while ( !isParsed )
            {
                onInput.Invoke();

                string input = Console.ReadLine() ?? string.Empty;

                if ( string.IsNullOrEmpty( input ) )
                {
                    continue;
                }

                isParsed = Enum.TryParse( input, ignoreCase: true, out result );

                if ( !isParsed )
                {
                    onError.Invoke();
                }
            }

            return result;
        }
    }
}