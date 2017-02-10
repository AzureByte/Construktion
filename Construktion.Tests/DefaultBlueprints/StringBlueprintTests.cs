﻿namespace Construktion.Tests.DefaultBlueprints
{
    using Blueprints;
    using Shouldly;
    using Xunit;

    public class StringBlueprintTests
    {
        [Fact]
        public void Can_Build_A_String()
        {
            var blueprint = new StringBlueprint();

            var result = (string)blueprint.Build(new ConstruktionContext(typeof(string)), Default.Pipeline);

            result.Substring(0, 7).ShouldBe("String-");
        }
    }
}