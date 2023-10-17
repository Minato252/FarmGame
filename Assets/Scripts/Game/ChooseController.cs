using UnityEngine;
using QFramework;

namespace FarmGame
{
	public partial class ChooseController : ViewController,ISingleton
	{

		public static ChooseController Instance => MonoSingletonProperty<ChooseController>.Instance;

		public void OnSingletonInit()
		{
			
		}
	}
}
