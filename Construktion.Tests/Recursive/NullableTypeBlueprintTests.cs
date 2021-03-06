﻿namespace Construktion.Tests.Recursive
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Blueprints.Recursive;
    using Shouldly;
    using Xunit;

    public class NullableTypeBlueprintTests
    {
        [Fact]
        public void should_match_nullable_types()
        {
            var blueprint = new NullableTypeBlueprint();
            var context = new ConstruktionContext(typeof(Foo).GetProperty("NullableAge"));

            var matches = blueprint.Matches(context);

            matches.ShouldBe(true);
        }

        [Fact]
        public void should_not_match_non_nullable_types()
        {
            var blueprint = new NullableTypeBlueprint();
            var context = new ConstruktionContext(typeof(Foo).GetProperty("Age"));

            var matches = blueprint.Matches(context);

            matches.ShouldBe(false);
        }

        [Fact]
        public void nullable_type_should_be_null_sometimes()
        {
            var blueprint = new NullableTypeBlueprint();
            var context = new ConstruktionContext(typeof(Foo).GetProperty("NullableAge"));

            var values = new List<int?>();

            for (var i = 0; i <= 30; i++)
            {
                var value = blueprint.Construct(context, Default.Pipeline);
                values.Add((int?)value);
            }

            values.Any(x => x == null).ShouldBe(true);
            values.Any(x => x != null).ShouldBe(true);
        }

        [Fact]
        public void should_not_match_reference_types()
        {
            var blueprint = new NullableTypeBlueprint();
            var context = new ConstruktionContext(typeof(Foo));

            var matches = blueprint.Matches(context);

            matches.ShouldBe(false);
        }

        public class Foo
        {
            public int Age { get; set; }
            public int? NullableAge { get; set; }
        }
    }
}