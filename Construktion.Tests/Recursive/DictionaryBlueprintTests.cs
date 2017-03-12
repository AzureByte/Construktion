namespace Construktion.Tests.Recursive
{
    using System.Collections.Generic;
    using Blueprints.Recursive;
    using Shouldly;
    using Xunit;

    public class DictionaryBlueprintTests
    {
        [Fact]
        public void should_build_dictionary()
        {
            var blueprint = new DictionaryBlueprint();

            var dictionary =
                (Dictionary<int, string>)
                blueprint.Construct(new ConstruktionContext(typeof(Dictionary<int, string>)), Default.Pipeline);

            dictionary.ShouldNotBe(null);
            dictionary.Count.ShouldBe(4);
        }

        [Fact]
        public void should_build_bool_keyed_dictionary()
        {
            var blueprint = new DictionaryBlueprint();

            var dictionary =
                (Dictionary<bool, string>)
                blueprint.Construct(new ConstruktionContext(typeof(Dictionary<bool, string>)), Default.Pipeline);

            dictionary.ShouldNotBe(null);
            dictionary.Count.ShouldBe(2);
        }

        [Fact]
        public void should_build_enum_keyed_dictionary()
        {
            var blueprint = new DictionaryBlueprint();

            var dictionary =
                (Dictionary<TestCaseResult, string>)
                blueprint.Construct(new ConstruktionContext(typeof(Dictionary<TestCaseResult, string>)),
                    Default.Pipeline);

            dictionary.ShouldNotBe(null);
            dictionary.Count.ShouldBe(3);
        }

        public enum TestCaseResult
        {
            Fail,
            Pass,
            Skip
        }
    }
}