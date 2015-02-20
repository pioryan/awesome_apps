namespace Smartass.Steps
{
    using System.Linq;
    using System.Threading.Tasks;
    using Smartass.Models;

    public abstract class StepBase
    {
        private StepBase[] asyncSubSteps;
        private StepBase next;

        public async Task RunAsync(Plan plan)
        {
            //await this.ProcessAsync(plan);
            await this.ProcessAndLogAsync(plan);
            await this.NextAsync(plan);
        }

        public StepBase ChainNext(StepBase next, params StepBase[] asyncSubSteps)
        {
            if (this.next != null)
            {
                this.next.ChainNext(next, asyncSubSteps);
            }
            else
            {
                this.next = next;
                this.asyncSubSteps = asyncSubSteps;
            }

            return this;
        }

        internal async Task NextAsync(Plan plan)
        {
            if (this.asyncSubSteps != null)
            {
                await Task.WhenAll(this.asyncSubSteps.Select(s => s.ProcessAndLogAsync(plan)).ToArray());
            }

            if (this.next != null)
            {
                await this.next.RunAsync(plan);
            }
        }

        protected abstract Task ProcessAsync(Plan plan);

        private async Task ProcessAndLogAsync(Plan plan)
        {
            log4net.LogManager.GetLogger("smartass").InfoFormat(
                System.Globalization.CultureInfo.InvariantCulture,
                "running step {0}",
                this.GetType().Name);
            try
            {
                await this.ProcessAsync(plan);
            }
            catch (System.Exception e)
            {
                log4net.LogManager.GetLogger("smartass").Error("exception during processing: ", e);
            }
        }
    }
}