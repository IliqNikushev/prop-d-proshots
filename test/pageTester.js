const chai = require('chai');
const request = require('chai-http');

chai.use(request);
chai.use(chai.should);

class SimplePageTester
{
	constructor(url)
	{
		this.url = url;
	}
	run(pages)
	{
		const server = chai.request(this.url);

		describe(this.url, function()
		{
			this.slow(1500);
			this.retries(2);
			this.timeout(30000);

			pages.forEach(path =>
			{
				it(`${path} should return a 200`, function(done)
				{
					server
						.get(path)
						.set('Cache-Control', 'no-cache')
						.end((err, res) =>
						{
							chai.expect(err).to.not.exist;
							res.should.have.status(200);
							done();
						});
				});
			});
		});
	}
}

module.exports = SimplePageTester;