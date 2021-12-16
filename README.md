## Sharp-IP  Vendors Device Manufacturer

C# Find the vendor / manufacturer of a device description  by IP/MAC Address from network adapter.

[![IEEE_Standard](https://github.com/KravitzMC/IPDeviceManufacturer/blob/main/iee.png)](https://regauth.standards.ieee.org/standards-ra-web/pub/view.html#registries)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/KravitzMC/IPDeviceManufacturer/blob/main/LICENSE)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FKravitzMC%2FIPDeviceManufacturer.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FKravitzMC%2FIPDeviceManufacturer?ref=badge_shield)

## Install via Nuget

[![NuGet Badge](https://buildstats.info/nuget/ZunMega.Net.DeviceManufacturer)](https://www.nuget.org/packages/ZunMega.Net.DeviceManufacturer)

##  Why must be this library ?

✔️ Fast IP/MAC scanner by using thread parallel.

✔️ Get more deivce information from IP/MAC by normal technical usually can't do it.

✔️ Vendors / Manufacturer from the IEEE Standards Association have over than 40000+ devices .

✔️ Deep scan MAC Address by without pinging because some client not response anytime. 
    but we use Send ARP lookup instead to get all devices info.

## Help or Feedback

Need help or have feedback?  Please file an issue here!

## Usage

```csharp
using System;
using System.Net;
using ZunMega.Net.DeviceManufacturer;

[Obsolete]
void Main(string[] args)
{
     //Set IP Address range from and to.    
     IPDeviceManufacturerScanner manufacturerScanner = new IPDeviceManufacturerScanner();
     manufacturerScanner.SetIPAddress(IPAddress.Parse("192.168.1.1"), IPAddress.Parse("192.168.1.255"));
     manufacturerScanner.ScanRecieved += ManufacturerScanner_ScanRecieved;
     manufacturerScanner.ScanComplete += ManufacturerScanner_ScanComplete;
     manufacturerScanner.StartScan();
     
     Console.ReadKey();
}

static void ManufacturerScanner_ScanRecieved(object sender, ScanRecievedEventArgs args)
{
	Console.WriteLine(
	$"IP Address : {args.IPAddress.ToString()} \n" +
	$"MAC Address : {args.MACAddress} \n" +
	$"Host Name : {args.HostName}\n" +
	$"Network Adapter Company : {args.CompanyName} \n" +
	$"Company Address : {args.CompanyAddress} \n" +
	$"Country Code : {args.CountryCode}\n" +
	$"Country Name : {args.CountryName}\n");
	Console.WriteLine("-----------------------------------------------------------");
}

static void ManufacturerScanner_ScanComplete(object sender, EventArgs e)
{
	Console.WriteLine("Complete..!!");
	Console.ReadKey();
}

```
---

Scan by default gateway (current network connection).

```csharp
manufacturerScanner.SetIPAddress();
```
---
Scan by custom IP range.
```csharp
manufacturerScanner.SetIPAddress(IPAddress.Parse("192.168.1.1"), IPAddress.Parse("192.168.1.255"));
```
---
Scan by IP Destination and return to your gateway router.
```csharp
manufacturerScanner.SetIPAddress(IPAddress.Parse("192.168.1.15"));
```
---

## Example Output
![Output](https://github.com/KravitzMC/IPDeviceManufacturer/blob/main/outputexample.png)


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Todo 

- [x] Convert Country Code to Country Name
- [ ] Convet to .NET Standard
- [ ] Add Mac Vendor automation update from Standard IEEE to DB (if some data change)
- [ ] Add Company Address automation update from Google API to Country Code (if some data change)
- [ ] Add some unit test
