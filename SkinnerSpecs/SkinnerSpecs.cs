using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skinner;

namespace SkinnerSpecs
{
    public class SkinnerSpecs:Spec
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
        }
    }
}
