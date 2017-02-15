using SmartRP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRP.Domain.StudentFunctions
{
	public class StudentService : IStudentService
	{

		#region Properties

		private readonly IWriteEntities _entities;

		#endregion

		#region Ctor

		public StudentService(IWriteEntities entities)
		{
			this._entities = entities;
		}

		#endregion

		#region IStudentService
        /*
        public Group CreateGroup(int leaderStudentId)
        {
            var group = this._entities.Single<Group>(s => s.ID == leaderStudentId);

            return group;
        }

        */

        /*
		public Job PostNewJob(int ownerClientId, string title, string description, int suburbId, int genderId, int serviceId, DateTime? serviceAt)
		{
			if (ownerClientId < 1)
				throw new ArgumentException("ownerClientId must be an ID greater than 1.");

			var client = this._entities.Single<Client>(c => c.ID == ownerClientId);
			if (client == null)
				throw new ArgumentNullException("client");

			var now = DateTime.Now;
			var clientId = client.ID;

			var job = new Job(clientId)
			{
				CreatedAt = now,
				UpdatedAt = now,
				Title = title,
				Description = description,
				SuburbId = suburbId,
				GenderId = genderId,
				ServiceId = serviceId,
				ServiceAt = serviceAt,
				JobStatus = "New"
			};

			client.PostedJobs.Add(job);

			this._entities.Update(client);
			this._entities.Save();

			return job;
		}

		public void EditJob(int ownerClientId, int jobId, string title, string description, int suburbId, int genderId, int serviceId, DateTime? servicedAt)
		{
			if (ownerClientId < 1)
				return;

			var client = this._entities.Single<Client>(c => c.ID == ownerClientId);
			if (client == null)
				throw new ArgumentNullException("client");

			var now = DateTime.Now;
			var clientId = client.ID;

			Job job = client.PostedJobs.SingleOrDefault<Job>(j => j.ID == jobId);
			if (job != null)
			{
				job.UpdatedAt = now;
				job.Title = title;
				job.Description = description;
				job.ServiceAt = servicedAt;
				job.SuburbId = suburbId;
				job.GenderId = genderId;
				job.ServiceId = serviceId;
				job.JobStatus = "Update";

				this._entities.Update(client);
				this._entities.Save();
			}
		}

		public void DeleteJob(int ownerClientId, int jobId)
		{
			if (ownerClientId < 1)
				return;

			var client = this._entities.Single<Client>(c => c.ID == ownerClientId);
			if (client == null)
				throw new ArgumentNullException("client");

			Job job = client.PostedJobs.SingleOrDefault(j => j.ID == jobId);
			if (job != null)
			{
				client.PostedJobs.Remove(job);

				this._entities.Delete(job);
				this._entities.Update(client);
				this._entities.Save();
			}
		}

        */
		#endregion

	}
}