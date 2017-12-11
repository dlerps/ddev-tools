using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DDev.Tools.Test
{
    public class ConvetionRegexTest
    {
        #region Positive Tests

        /// <summary>
        /// Checks the lowerCamelCase check
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("atroksieMeansOwl")]
        [InlineData("kirineMeansHappy")]
        [InlineData("syzMeansGood")]
        public void IsLowerCamelCase_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsLowerCamelCase(test)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the lowerCamelCase check
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("mayThe4BeWithYou")]
        [InlineData("illBeThere4You")]
        [InlineData("theCrazy88")]
        public void IsLowerCamelCase_ShouldReturnTrue_WhenInputHasDigits(string test)
        {
            ConventionRegex.IsLowerCamelCase(test, allowNumbers: true)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the UpperCamelCase check
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("TheNightsWatch")]
        [InlineData("MiddleEarth")]
        [InlineData("EvergreenTerrace")]
        public void IsUpperCamelCase_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsUpperCamelCase(test)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks if the IsUpperCamelCase allows numbers
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("Yavin4RebelBase")]
        [InlineData("Red5Batallion")]
        public void IsUpperCamelCase_ShouldReturnTrue_WhenInputHasDigits(string test)
        {
            ConventionRegex.IsUpperCamelCase(test, allowNumbers: true)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("bat-girl")]
        [InlineData("the-incredible-hulk")]
        [InlineData("darth-vader")]
        public void IsKebabCase_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsKebabCase(test)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("iron_man")]
        [InlineData("winter_is_coming")]
        [InlineData("minions")]
        public void IsSnakeCase_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsSnakeCase(test)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("brooklyn_99")]
        [InlineData("the-upside_down")]
        public void IsMixedKebabSnakeCase_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsMixedKebabSnakeCase(test)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the dot.notation
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("castle.black")]
        [InlineData("the.summer.islands")]
        [InlineData("the.forest.moon.endor")]
        public void IsDotNotation_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsDotNotation(test, maxLength: 21)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the dot.notation
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("EAST.WATCH.BY.THE.SEA")]
        [InlineData("BALON.GREYJOY")]
        public void IsDotNotation_ShouldTakeCaptialLetters_WhenCaptialEnumIsUsed(string test)
        {
            ConventionRegex.IsDotNotation(test, allowedLetters: RegexLetterCase.CapitalOnly, maxLength: 25)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the dot.notation
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("first.of.the.1st.men")]
        [InlineData("51st.state")]
        public void IsDotNotation_ShouldTakeacceptNumbers_WhenOptionIsSet(string test)
        {
            ConventionRegex.IsDotNotation(test, allowNumbers: true)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the snake_case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("Padme_Amidala")]
        [InlineData("my_little_Pony")]
        public void IsSnakeCase_ShoulAcceptCapitalLetters_WhenEnumBothIsUsed(string test)
        {
            ConventionRegex.IsSnakeCase(test, allowedLetters: RegexLetterCase.Both)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("the-Hunger-Games")]
        [InlineData("Luke-Skywalker")]
        public void IsKebabCase_ShoulAcceptCapitalLetters_WhenEnumBothIsUsed(string test)
        {
            ConventionRegex.IsKebabCase(test, allowedLetters: RegexLetterCase.Both)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("Essos_over-Westeros")]
        [InlineData("the-army-of-the_DEAD")]
        public void IsMixedKebabSnakeCase_ShoulAcceptCapitalLetters_WhenEnumBothIsUsed(string test)
        {
            ConventionRegex.IsMixedKebabSnakeCase(test, allowedLetters: RegexLetterCase.Both)
                .Should()
                .BeTrue();
        }

        #endregion

        #region Length Tests

        /// <summary>
        /// Checks the kebab-case max length
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("daenerys-stormborn-of-house-targeryen")]
        [InlineData("the-wizard-of-the-north")]
        public void IsKebabCase_ShoulAcceptLongInputs_WhenMaxIsChanged(string test)
        {
            ConventionRegex.IsKebabCase(test, maxLength: 37)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the snake_case max length
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("1_ring_to_rule_them_all")]
        [InlineData("and_now_his_watch_has_ended")]
        public void IsSnakeCase_ShoulAcceptLongInputs_WhenMaxIsChanged(string test)
        {
            ConventionRegex.IsSnakeCase(test, maxLength: 28, allowNumbers: true)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the UpperCamelCase max length
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("ISwaerByMyPrettyPinkBonnetIEndYou")]
        [InlineData("ALannisterAlwaysPaysHisDebts")]
        public void IsUpperCamelCase_ShoulAcceptLongInputs_WhenMaxIsChanged(string test)
        {
            ConventionRegex.IsUpperCamelCase(test, maxLength: 50)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the lowerCamelCase max length
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("theClanOfTheAssissins")]
        [InlineData("mayTheOddsBeEverInYourFavour")]
        public void IsLowerCamelCase_ShoulAcceptLongInputs_WhenMaxIsChanged(string test)
        {
            ConventionRegex.IsLowerCamelCase(test, maxLength: 40)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the kebab-case min length
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("my-prescious")]
        [InlineData("its-a-trap")]
        public void IsKebabCase_ShoulRejectShortInputs_WhenNotMatchingMinLength(string test)
        {
            ConventionRegex.IsKebabCase(test, minLength: 15, maxLength: 30)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the camelCase min length
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("ValarMorghulis")]
        [InlineData("ValarDohaerys")]
        public void IsUpperCamelCase_ShoulRejectShortInputs_WhenNotMatchingMinLength(string test)
        {
            ConventionRegex.IsUpperCamelCase(test, minLength: 15, maxLength: 30)
                .Should()
                .BeFalse();
        }

        #endregion

        #region Negative Tests

        /// <summary>
        /// Checks the camelCase
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("the_king_of_the_north")]
        [InlineData("Homer Simposon")]
        public void IsUpperCamelCase_ShoulRejectInputs_WhenInWrongFormat(string test)
        {
            ConventionRegex.IsUpperCamelCase(test, maxLength: 40)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the camelCase
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("FitzChilvallryFarseer")]
        [InlineData("ship-of-firefly-class")]
        public void IsLowerCamelCase_ShoulRejectInputs_WhenInWrongFormat(string test)
        {
            ConventionRegex.IsLowerCamelCase(test, maxLength: 40)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the sanke_case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("the-big-bang-theory")]
        [InlineData("death_ all_mankind")]
        public void IsSnakeCase_ShoulRejectInputs_WhenInWrongFormat(string test)
        {
            ConventionRegex.IsSnakeCase(test)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("Tatooine")]
        [InlineData("joey_tribbiani")]
        public void IsKebabCase_ShoulRejectInputs_WhenInWrongFormat(string test)
        {
            ConventionRegex.IsKebabCase(test)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the kebab-case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("embrace-the-dark-Side")]
        public void IsKebabCase_ShoulRejectCapitalInputs_WhenNotPermitted(string test)
        {
            ConventionRegex.IsSnakeCase(test, maxLength: 25)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the snake_case
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("Yippi_kay_yay_motherfucker")]
        public void IsSnakeCase_ShoulRejectCapitalInputs_WhenNotPermitted(string test)
        {
            ConventionRegex.IsSnakeCase(test, maxLength: 37)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the dot.notation
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("volantis")]
        [InlineData("Minas.Morghul")]
        public void IsDotNotation_ShoulRejectLowerCase_WhenCaptialOnlyIsUsed(string test)
        {
            ConventionRegex.IsDotNotation(test, allowedLetters: RegexLetterCase.CapitalOnly)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the dot.notation
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("embrace-the-dark-side")]
        [InlineData("ay_caramba")]
        public void IsDotNotation_ShoulRejectInput_WhenWrongCase(string test)
        {
            ConventionRegex.IsDotNotation(test)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks the dot.notation
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("You.shall.not.pass!")]
        [InlineData("thats.not.a.knive,thats.a.knive")]
        public void IsDotNotation_ShoulRejectInput_WhenForbiddenCharactersAreUsed(string test)
        {
            ConventionRegex.IsDotNotation(test)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks negagive for number inputs
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("there_are_5_xmen")]
        public void IsSnakeCase_ShoulRejectNumbers_WhenAllowNumbersIsFalse(string test)
        {
            ConventionRegex.IsSnakeCase(test, allowNumbers: false)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks negagive for number inputs
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("dragon.stone")]
        [InlineData("the.red-keep")]
        [InlineData("serving.the-faceless_god")]
        public void IsMixedKebabSnakeCase_ShoulRejectDots(string test)
        {
            ConventionRegex.IsSnakeCase(test, allowNumbers: false, maxLength: 30)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks negagive for number inputs
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("TheAnswerToTheUltimateQuestionIs42")]
        public void IsUpperCamelCase_ShoulRejectNumbers_WhenAllowNumbersIsFalse(string test)
        {
            ConventionRegex.IsUpperCamelCase(test, allowNumbers: false, maxLength: 50)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks negagive for number inputs
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("theOddsAre100MillionToOne")]
        public void IsLowerCamelCase_ShoulRejectNumbers_WhenAllowNumbersIsFalse(string test)
        {
            ConventionRegex.IsLowerCamelCase(test, allowNumbers: false, maxLength: 30)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks negagive for number inputs
        /// </summary>
        /// <param name="test"></param>
        [Theory]
        [InlineData("i-see-double-4-krusties")]
        public void IsKebabCase_ShoulRejectNumbers_WhenAllowNumbersIsFalse(string test)
        {
            ConventionRegex.IsKebabCase(test, allowNumbers: false, maxLength: 30)
                .Should()
                .BeFalse();
        }

        #endregion
    }
}
