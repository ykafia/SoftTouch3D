using System;
using System.Linq;
using ECSharp;
using System.Collections.Generic;
using SPIRVCross;
using static SPIRVCross.SPIRV;

namespace SoftTouch
{

    public class Program
    {
        public static void Main(string[] args)
        {

            var shader = ShaderProgram.GetTriangleVert();

            unsafe
            {
                fixed (byte* ptr = shader)
                {
                    var spirv = (SpvId*)ptr;

                    uint wordcount = (uint)shader.Length / 4;
                    spvc_context ctx = default;
                    spvc_parsed_ir ir;

                    spvc_compiler compiler_glsl;
                    spvc_compiler_options options;
                    spvc_resources resources;
                    spvc_reflected_resource* list = default;
                    nuint count = default;
                    spvc_error_callback error_callback = default;

                    // Create context.
                    spvc_context_create(&ctx);

                    // Set debug callback.
                    spvc_context_set_error_callback(ctx, error_callback, null);

                    // Parse the SPIR-V.
                    spvc_context_parse_spirv(ctx, spirv, wordcount, &ir);

                    // Hand it off to a compiler instance and give it ownership of the IR.
                    spvc_context_create_compiler(ctx, spvc_backend.Glsl, ir, spvc_capture_mode.TakeOwnership, &compiler_glsl);

                    // Do some basic reflection.
                    spvc_compiler_create_shader_resources(compiler_glsl, &resources);
                    spvc_resources_get_resource_list_for_type(resources, spvc_resource_type.UniformBuffer, (spvc_reflected_resource*)&list, &count);

                    var model = spvc_compiler_get_execution_model(compiler_glsl);
                    for (uint i = 0; i < count; i++)
                    {
                        uint set = spvc_compiler_get_decoration(compiler_glsl, (SpvId)list[i].id, SpvDecoration.SpvDecorationDescriptorSet);
                        uint binding = spvc_compiler_get_decoration(compiler_glsl, (SpvId)list[i].id, SpvDecoration.SpvDecorationBinding);
                        uint offset = spvc_compiler_get_decoration(compiler_glsl, (SpvId)list[i].id, SpvDecoration.SpvDecorationOffset);
                        spvc_type type = spvc_compiler_get_type_handle(compiler_glsl, (SpvId)list[i].type_id);

                        nuint size = 0;
                        spvc_compiler_get_declared_struct_size(compiler_glsl, type, &size);


                        Console.WriteLine(size);


                        Console.WriteLine("=========");
                    }
                    Console.WriteLine("\n \n");
                    spvc_context_destroy(ctx);
                }
            }

            IGame g = new VKGame();

            g.Run();
            var w = new World();
            var e = w.CreateEntity()
                .With(new NameComponent { Name = "John" })
                .With(new AgeComponent())
                .Build();
            w[e.Index].Remove<NameComponent>();
        }
    }
}