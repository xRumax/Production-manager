using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace EndLand.Data.Models;

public partial class NetLandContext : DbContext
{
    public NetLandContext()
    {
    }

    public NetLandContext(DbContextOptions<NetLandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<RobotCartonsFinish> RobotCartonsFinishes { get; set; }

    public virtual DbSet<RobotCartonsInitial> RobotCartonsInitials { get; set; }

    public virtual DbSet<RobotConfiguration> RobotConfigurations { get; set; }

    public virtual DbSet<RobotDevicesProg> RobotDevicesProgs { get; set; }

    public virtual DbSet<RobotWaterMeter> RobotWaterMeters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => new { e.Imei, e.CreatedAt }).HasName("incidents_pkey");

            entity.ToTable("incidents");

            entity.Property(e => e.Imei).HasColumnName("imei");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Exception).HasColumnName("exception");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.ProjectName).HasColumnName("project_name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserName).HasColumnName("user_name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.SuddenWaterLossAlarmCounterThreshold).HasColumnName("sudden_water_loss_alarm_counter_threshold");
            entity.Property(e => e.SuddenWaterLossAlarmInterval).HasColumnName("sudden_water_loss_alarm_interval");
            entity.Property(e => e.SuddenWaterLossAlarmLowerThreshold).HasColumnName("sudden_water_loss_alarm_lower_threshold");
            entity.Property(e => e.WaterLeakAlarmCounterThreshold).HasColumnName("water_leak_alarm_counter_threshold");
            entity.Property(e => e.WaterLeakAlarmInterval).HasColumnName("water_leak_alarm_interval");
            entity.Property(e => e.WaterLeakAlarmLowerThreshold).HasColumnName("water_leak_alarm_lower_threshold");
            entity.Property(e => e.WaterMeterConstFlowRate).HasColumnName("water_meter_const_flow_rate");
            entity.Property(e => e.WaterMeterDiameter).HasColumnName("water_meter_diameter");
            entity.Property(e => e.WaterMeterMeasuringRange).HasColumnName("water_meter_measuring_range");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => new { e.Imei, e.CreatedAt }).HasName("reports_pkey");

            entity.ToTable("reports");

            entity.Property(e => e.Imei).HasColumnName("imei");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Ccid).HasColumnName("ccid");
            entity.Property(e => e.EsiAfe1BaseChannel0).HasColumnName("esi_afe1_base_channel0");
            entity.Property(e => e.EsiAfe1BaseChannel1).HasColumnName("esi_afe1_base_channel1");
            entity.Property(e => e.EsiAfe1BaseChannel2)
                .HasDefaultValue(0)
                .HasColumnName("esi_afe1_base_channel2");
            entity.Property(e => e.EsiAfe2BaseChannel0).HasColumnName("esi_afe2_base_channel0");
            entity.Property(e => e.EsiAfe2BaseChannel1).HasColumnName("esi_afe2_base_channel1");
            entity.Property(e => e.EsiAfe2BaseChannel2)
                .HasDefaultValue(0)
                .HasColumnName("esi_afe2_base_channel2");
            entity.Property(e => e.EsiThresholdChannel0).HasColumnName("esi_threshold_channel0");
            entity.Property(e => e.EsiThresholdChannel1).HasColumnName("esi_threshold_channel1");
            entity.Property(e => e.EsiThresholdChannel2)
                .HasDefaultValue(0)
                .HasColumnName("esi_threshold_channel2");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("finished_at");
            entity.Property(e => e.FirmwareVersion).HasColumnName("firmware_version");
            entity.Property(e => e.Model).HasColumnName("model");
            entity.Property(e => e.OrderNumber).HasColumnName("order_number");
            entity.Property(e => e.ProjectName).HasColumnName("project_name");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.StartedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("started_at");
            entity.Property(e => e.SuddenWaterLossAlarmCounterThreshold).HasColumnName("sudden_water_loss_alarm_counter_threshold");
            entity.Property(e => e.SuddenWaterLossAlarmInterval).HasColumnName("sudden_water_loss_alarm_interval");
            entity.Property(e => e.SuddenWaterLossAlarmLowerThreshold).HasColumnName("sudden_water_loss_alarm_lower_threshold");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.Volume).HasColumnName("volume");
            entity.Property(e => e.WaterLeakAlarmCounterThreshold).HasColumnName("water_leak_alarm_counter_threshold");
            entity.Property(e => e.WaterLeakAlarmInterval).HasColumnName("water_leak_alarm_interval");
            entity.Property(e => e.WaterLeakAlarmLowerThreshold).HasColumnName("water_leak_alarm_lower_threshold");
            entity.Property(e => e.WaterMeterConstFlowRate).HasColumnName("water_meter_const_flow_rate");
            entity.Property(e => e.WaterMeterDiameter).HasColumnName("water_meter_diameter");
        });

        modelBuilder.Entity<RobotCartonsFinish>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("robot_cartons_finish_pk");

            entity.ToTable("robot_cartons_finish");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("admission_date");
            entity.Property(e => e.Dn).HasColumnName("dn");
            entity.Property(e => e.FullCarton)
                .HasDefaultValue(false)
                .HasColumnName("full_carton");
            entity.Property(e => e.MaxPixelCount).HasColumnName("max_pixel_count");
            entity.Property(e => e.MinPixelCount).HasColumnName("min_pixel_count");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Purpose).HasColumnName("purpose");
            entity.Property(e => e.Q3).HasColumnName("q3");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TestResult).HasColumnName("test_result");
        });

        modelBuilder.Entity<RobotCartonsInitial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("robot_cartons_initial_pk");

            entity.ToTable("robot_cartons_initial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdmissionDate).HasColumnName("admission_date");
            entity.Property(e => e.Dn).HasColumnName("dn");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Purpose).HasColumnName("purpose");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
        });

        modelBuilder.Entity<RobotConfiguration>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("robot_configuration");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.PixelTreshold).HasColumnName("pixel_treshold");
            entity.Property(e => e.QuantityWaterMetersInCarton).HasColumnName("quantity_water_meters_in_carton");
        });

        modelBuilder.Entity<RobotDevicesProg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("robot_devices_prog_pk");

            entity.ToTable("robot_devices_prog");

            entity.HasIndex(e => new { e.Id, e.Device, e.FirmwareVer, e.Imei, e.StartedAt, e.FinishedAt }, "robot_devices_prog_id_idx");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('newtable_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Device).HasColumnName("device");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.FirmwareVer).HasColumnName("firmware_ver");
            entity.Property(e => e.Imei).HasColumnName("imei");
            entity.Property(e => e.StartedAt).HasColumnName("started_at");
        });

        modelBuilder.Entity<RobotWaterMeter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("robot_water_meter_pk");

            entity.ToTable("robot_water_meter");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dn).HasColumnName("dn");
            entity.Property(e => e.IdCartonFinish).HasColumnName("id_carton_finish");
            entity.Property(e => e.IdCartonInitial).HasColumnName("id_carton_initial");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.PixelCount)
                .HasComment("czym więcej to lepiej")
                .HasColumnName("pixel_count");
            entity.Property(e => e.PixelCount2)
                .HasComment("czym mniej to lepiej")
                .HasColumnName("pixel_count_2");
            entity.Property(e => e.Purpose).HasColumnName("purpose");
            entity.Property(e => e.Q3).HasColumnName("q3");
            entity.Property(e => e.SerialNumber).HasColumnName("serial_number");
            entity.Property(e => e.TestResult).HasColumnName("test_result");
            entity.Property(e => e.YearLegalization).HasColumnName("year_legalization");
            entity.Property(e => e.YearSecondaryLegalization).HasColumnName("year_secondary_legalization");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PinCode).HasColumnName("pin_code");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public async Task SaveOrHandleExceptionAsync() 
    {
        try 
        { 
            await this.SaveChangesAsync();
        } 
        catch (Exception ex) 
        { 
            Log.Logger.Error(ex.Message);
            Log.Logger.Error(ex.StackTrace); 
            throw; 
        } 
    }
}
