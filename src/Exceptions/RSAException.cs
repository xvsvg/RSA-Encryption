namespace RSAEncryption.Exceptions;

public class RSAException : RSAEncryptionException
{
	private RSAException(string message)
		: base(message) { }

	public static RSAException UnableToEncryptEmptyInputDataException(string message)
		=> new RSAException(message);
}
