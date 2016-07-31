using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skinner;

namespace SkinnerSpecs
{
    public class SkinnerSpecs : Spec
    {
        public override void Specs()
        {
            describe("Skinner", () =>
            {
                it("should compile", () =>
                {

                });
                it("should make true assertions", () =>
                {
                    expect(true).toBe(true);
                });
            });
            describe("Skinner", () =>
            {
                it("should accept multiple descriptions", () =>
                {

                });
            });
            describe("Skinner descriptions", () =>
            {
                it("should run a single description", () =>
                {
                    var spec = new SingleDescriptionTestSpec();
                    spec.Run();
                });
                it("should notify that it's running a description", () =>
                {
                    var spec = new SingleDescriptionTestSpec();
                    string description = "shit just got real";
                    spec.onDescription += (o, a) => description = a.Description;
                    spec.Run();
                    expect(description).toBe("Single Description Spec");
                });
            });
        }
    }

    class SingleDescriptionTestSpec : Spec
    {
        public override void Specs()
        {
            describe("Single Description Spec", () =>
            {

            });
        }
    }
}
