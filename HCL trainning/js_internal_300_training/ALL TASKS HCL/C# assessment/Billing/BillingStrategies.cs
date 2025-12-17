namespace HospitalPMS.Billing;

public static class BillingStrategies
{
    public static BillingStrategy Standard()
        => amount => amount;

    public static BillingStrategy Insurance(decimal coveragePercent)
    {
        coveragePercent = Math.Clamp(coveragePercent, 0m, 100m);
        return amount =>
        {
            decimal patientPaysPercent = 100m - coveragePercent;
            return amount * (patientPaysPercent / 100m);
        };
    }

    public static BillingStrategy SeniorCitizenDiscount(decimal discountPercent)
    {
        discountPercent = Math.Clamp(discountPercent, 0m, 100m);
        return amount => amount * (1m - (discountPercent / 100m));
    }

    public static BillingStrategy EmergencySurcharge(decimal surchargePercent)
    {
        surchargePercent = Math.Clamp(surchargePercent, 0m, 100m);
        return amount => amount * (1m + (surchargePercent / 100m));
    }
}
