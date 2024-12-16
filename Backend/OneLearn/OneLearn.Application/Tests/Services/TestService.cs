using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using OneLearn.Application.Tests.DTOs.Request;
using OneLearn.Application.Tests.Interface;
using OneLearn.Domain.Test;

namespace OneLearn.Application.Tests.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        public TestService(ITestRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task UpdateTestAsync(int id, UpdateTestDto request)
        {
            var test = await _testRepository.GetByIdAsync(x => x.id == id);

            test.a = request.a;
            test.b = request.b;
            test.c = request.c;
            test.d = request.d;
            test.e = request.e;
            test.f = request.f;
            test.g = request.g;
            test.h = request.h;
            test.i = request.i;
            test.j = request.j;
            test.k = request.k;
            test.l = request.l;
            test.m = request.m;
            test.n = request.n;

            await _testRepository.UpdateAsAsync(test);
        }

        public async Task UpdatePatchTestAsync(int id, JsonPatchDocument<UpdateTestDto> patch)
        {
            var test = await _testRepository.GetByIdAsync(x => x.id == id);

            if (test == null)
            {
                throw new KeyNotFoundException($"Test with ID {id} not found.");
            }

            var testDto = new UpdateTestDto
            {
                a = test.a,
                b = test.b,
                c = test.c,
                d = test.d,
                e = test.e,
                f = test.f,
                g = test.g,
                h = test.h,
                i = test.i,
                j = test.j,
                k = test.k,
                l = test.l,
                m = test.m,
                n = test.n
            };

            patch.ApplyTo(testDto);

            test.a = testDto.a;
            test.b = testDto.b;
            test.c = testDto.c;
            test.d = testDto.d;
            test.e = testDto.e;
            test.f = testDto.f;
            test.g = testDto.g;
            test.h = testDto.h;
            test.i = testDto.i;
            test.j = testDto.j;
            test.k = testDto.k;
            test.l = testDto.l;
            test.m = testDto.m;
            test.n = testDto.n;
            await _testRepository.UpdateAsAsync(test);

        }

    }
}
