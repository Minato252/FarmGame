using UnityEngine;
using QFramework;

namespace FarmGame
{
	public partial class ResController : ViewController,ISingleton
        
	{
		public GameObject SeedPrefabs;

		public static ResController Instance => MonoSingletonProperty<ResController>.Instance;
		void Start()
		{
			// Code Here
		}

		public void OnSingletonInit()
		{
			
		}
	}
}
