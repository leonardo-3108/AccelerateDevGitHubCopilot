using NSubstitute;
using Library.ApplicationCore;
using Library.ApplicationCore.Entities;
using Microsoft.Extensions.Configuration;
using Library.Infrastructure.Data;
using Xunit;

namespace UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoanTest
{
    private readonly ILoanRepository _mockLoanRepository;
    private readonly JsonLoanRepository _jsonLoanRepository;
    private readonly IConfiguration _configuration;
    private readonly JsonData _jsonData;

    public GetLoanTest()
    {
        _configuration = new ConfigurationBuilder().Build();
        _jsonData = new JsonData(_configuration);
        _mockLoanRepository = Substitute.For<ILoanRepository>();
        _jsonLoanRepository = new JsonLoanRepository(_jsonData);
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when loan ID is found")]
    public async Task GetLoan_ReturnsLoan_WhenLoanIdIsFound()
    {
        // Arrange
        var loanId = 1; // Use a loan ID that exists in the Loans.json file
        var expectedLoan = new Loan
        {
            Id = loanId,
            BookItemId = 101,
            PatronId = 1001,
            LoanDate = DateTime.Now.AddDays(-10),
            DueDate = DateTime.Now.AddDays(10),
            ReturnDate = null
        };

        _mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.NotNull(actualLoan);
        Assert.Equal(expectedLoan.Id, actualLoan?.Id);
    }

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when loan ID is not found")]
    public async Task GetLoan_ReturnsNull_WhenLoanIdIsNotFound()
    {
        // Arrange
        var loanId = 999; // Use a loan ID that does not exist in the Loans.json file
        _mockLoanRepository.GetLoan(loanId).Returns((Loan?)null);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.Null(actualLoan);
    }
}