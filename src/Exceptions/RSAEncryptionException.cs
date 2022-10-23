namespace RSAEncryption.Exceptions;

public class RSAEncryptionException : Exception
{
	public RSAEncryptionException()
		: base() { }

	public RSAEncryptionException(string message)
		: base(message) { }

	public RSAEncryptionException(string message, Exception? innerException)
		: base(message, innerException) { }
}
