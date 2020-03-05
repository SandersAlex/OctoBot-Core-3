using System.Linq;
using NUnit.Framework;
using OctoBot;
using OctoBot.Tentacles.Manager;

namespace NUnitTestProject
{
	[TestFixture]
	public class TentacleUtilTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[TestCase(TypeEnum.Evaluator, "RealTime", "Default", false)]
		public static void CreatePathFromTypeTest(TypeEnum moduleType, string moduleSubtype, string targetFolder, bool tests = false)
		{
			// create path from types
			string testFolderIfRequired = "";

			if (tests == true) testFolderIfRequired = $"/{TentaclesManagerVars.TENTACLES_TEST_PATH}";

			string value = "";

			string mt = moduleType.ToString();
			string mtv = "";
			string mst = "";

			foreach (var index in TentaclesManagerVars.TENTACLE_TYPES)
			{
				foreach (var subIndex in index)
				{
					if (subIndex.Key == mt) mtv = subIndex.Value;
					if (subIndex.Key == moduleSubtype) mst = subIndex.Value;
				}
			}

			if (moduleSubtype != "") value = $"{TentaclesManagerVars.TENTACLES_PATH}{testFolderIfRequired}/{mtv}/" + $"{mst}/{targetFolder}";
			else value = $"{TentaclesManagerVars.TENTACLES_PATH}{testFolderIfRequired}/{mtv}/{targetFolder}";

			Assert.True(value != "");
		}
	}
}