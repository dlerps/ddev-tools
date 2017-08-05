using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDev.Tools.Test
{
    [TestFixture]
    [Author("Daniel Lerps")]
    public class ConvetionRegexTest
    {
        #region Positive Tests

        /// <summary>
        /// Checks the lowerCamelCase check
        /// </summary>
        /// <param name="test"></param>
        [TestCase("atroksieMeansOwl")]
        [TestCase("kirineMeansHappy")]
        [TestCase("syzMeansGood")]
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
        [TestCase("mayThe4BeWithYou")]
        [TestCase("illBeThere4You")]
        [TestCase("theCrazy88")]
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
        [TestCase("TheNightsWatch")]
        [TestCase("MiddleEarth")]
        [TestCase("EvergreenTerrace")]
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
        [TestCase("Yavin4RebelBase")]
        [TestCase("Red5Batallion")]
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
        [TestCase("bat-girl")]
        [TestCase("the-incredible-hulk")]
        [TestCase("darth-vader")]
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
        [TestCase("iron_man")]
        [TestCase("winter_is_coming")]
        [TestCase("minions")]
        public void IsSnakeCase_ShouldReturnTrue_WhenInputIsValid(string test)
        {
            ConventionRegex.IsSnakeCase(test)
                .Should()
                .BeTrue();
        }

        /// <summary>
        /// Checks the snake_case
        /// </summary>
        /// <param name="test"></param>
        [TestCase("Padme_Amidala")]
        [TestCase("my_little_Pony")]
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
        [TestCase("the-Hunger-Games")]
        [TestCase("Luke-Skywalker")]
        public void IsKebabCase_ShoulAcceptCapitalLetters_WhenEnumBothIsUsed(string test)
        {
            ConventionRegex.IsKebabCase(test, allowedLetters: RegexLetterCase.Both)
                .Should()
                .BeTrue();
        }

        #endregion

        #region Length Tests

        /// <summary>
        /// Checks the kebab-case max length
        /// </summary>
        /// <param name="test"></param>
        [TestCase("daenerys-stormborn-of-house-targeryen")]
        [TestCase("the-wizard-of-the-north")]
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
        [TestCase("1_ring_to_rule_them_all")]
        [TestCase("and_now_his_watch_has_ended")]
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
        [TestCase("ISwaerByMyPrettyPinkBonnetIEndYou")]
        [TestCase("ALannisterAlwaysPaysHisDebts")]
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
        [TestCase("theClanOfTheAssissins")]
        [TestCase("mayTheOddsBeEverInYourFavour")]
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
        [TestCase("my-prescious")]
        [TestCase("its-a-trap")]
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
        [TestCase("ValarMorghulis")]
        [TestCase("ValarDohaerys")]
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
        [TestCase("the_king_of_the_north")]
        [TestCase("Homer Simposon")]
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
        [TestCase("FitzChilvallryFarseer")]
        [TestCase("ship-of-firefly-class")]
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
        [TestCase("the-big-bang-theory")]
        [TestCase("death_ all_mankind")]
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
        [TestCase("Tatooine")]
        [TestCase("joey_tribbiani")]
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
        [TestCase("embrace-the-dark-Side")]
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
        [TestCase("Yippi_kay_yay_motherfucker")]
        public void IsSnakeCase_ShoulRejectCapitalInputs_WhenNotPermitted(string test)
        {
            ConventionRegex.IsSnakeCase(test, maxLength: 37)
                .Should()
                .BeFalse();
        }

        /// <summary>
        /// Checks negagive for number inputs
        /// </summary>
        /// <param name="test"></param>
        [TestCase("there_are_5_xmen")]
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
        [TestCase("TheAnswerToTheUltimateQuestionIs42")]
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
        [TestCase("theOddsAre100MillionToOne")]
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
        [TestCase("i-see-double-4-krusties")]
        public void IsKebabCase_ShoulRejectNumbers_WhenAllowNumbersIsFalse(string test)
        {
            ConventionRegex.IsKebabCase(test, allowNumbers: false, maxLength: 30)
                .Should()
                .BeFalse();
        }

        #endregion
    }
}
