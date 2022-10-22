namespace RSAEncryption.Models;

public sealed class PrivateKey
{
	public PrivateKey(ModuloNumber moduloNumber, int key)
	{
		ArgumentNullException.ThrowIfNull(moduloNumber);

		ModuloNumber = moduloNumber;
		Key = key;
	}

	public ModuloNumber ModuloNumber { get; }
	public int Key { get; }
}
