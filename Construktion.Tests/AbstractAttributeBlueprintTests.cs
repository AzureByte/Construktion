﻿namespace Construktion.Tests
{
    using System;
    using System.Reflection;
    using Blueprints;
    using Shouldly;
    using Xunit;

    public class AbstractAttributeBlueprintTests
    {
        [Fact]
        public void should_match_property_with_attribute()
        {
            var blueprint = new SetBlueprint();
            var property = typeof(Foo).GetProperty("WithSet");
            var context = new ConstruktionContext(property);

            var matches = blueprint.Matches(context);

            matches.ShouldBe(true);
        }

        [Fact]
        public void property_without_attribute_should_not_match()
        {
            var blueprint = new SetBlueprint();
            var property = typeof(Foo).GetProperty("WithoutSet");
            var context = new ConstruktionContext(property);

            var matches = blueprint.Matches(context);

            matches.ShouldBe(false);
        }

        [Fact]
        public void should_construct_from_attribute_value()
        {
            var blueprint = new SetBlueprint();
            var property = typeof(Foo).GetProperty("WithSet");
            var context = new ConstruktionContext(property);

            var result = (string)blueprint.Construct(context, Default.Pipeline);

            result.ShouldBe("Set");
        }

        public class SetBlueprint : AbstractAttributeBlueprint<Set>
        {
            public override object Construct(ConstruktionContext context, ConstruktionPipeline pipeline)
            {
                return GetAttribute(context).Value;
            }
        }

        public class Foo
        {
            [Set("Set")]
            public string WithSet { get; set; }
            public string WithoutSet { get; set; }
        }


        public class Set : Attribute
        {
            public object Value { get; }

            public Set(object value)
            {
                Value = value;
            }
        }
    }
}