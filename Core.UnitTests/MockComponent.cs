using Moq;

namespace Lithomancer.Core
{
	public static class MockComponent
	{
		public static IComponent<T> Create<T>(Mock<T> mock) where T : class
		{
			Mock<IComponent<T>> mockComponent = new Mock<IComponent<T>>();
			mockComponent.SetupGet(m => m.Object).Returns(mock.Object);
			return mockComponent.Object;
		}
	}
}
