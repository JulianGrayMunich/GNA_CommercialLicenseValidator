# GNA_CommercialLicenseValidator

**Commercial License Validation Library for GNA Software Components**

This DLL provides runtime validation of software license codes for client applications using GNA commercial software modules. It ensures licensing integrity by verifying software code identity and license expiry.

Both input data strings (software code and license code) are supplied by GNA Geomatics, through the Commercial License Generator (Part 1 of this 2 part software package)

---

## 🔧 Installation

### Option 1: Manual DLL Reference

1. Download `GNA_CommercialLicenseValidator.dll` from the [Releases](https://github.com/YourUsername/GNA_CommercialLicenseValidator/releases) section.
2. In your Visual Studio project:
   - Right-click on your project → **Add Reference**
   - Click **Browse...** and select the downloaded DLL.
3. Add the namespace in your code:
```csharp
using GNA_CommercialLicenseValidator;
```

---

## ✅ Usage Example

```csharp
using System;
using GNA_CommercialLicenseValidator;

class Program
{
    static void Main()
    {
        string softwareCode = "TEST01";
        string licenseCode = "XXXXXXXXYYYYYYYY"; // Replace with actual code

        // Validate license at application start
        LicenseValidator.ValidateLicense(softwareCode, licenseCode);

        // Continue only if license is valid
        Console.WriteLine("License is valid. Application continues...");
    }
}
```

---

## 🔐 License Code Structure

- Total length: **16 characters**
- Composed of two parts:
  - **8 characters for software code block**
  - **8 characters for expiry date block**
- Each block is Base64-encoded after lightweight XOR encryption.

---

## ⚠ Validation Behavior

- If the **software code does not match**, the application terminates.
- If the **license is expired**, the application terminates.
- If the license **expires within 5 days**, a warning message is displayed, but execution continues.
- If the license is **valid**, the application continues silently.

---

## 📩 License Renewal

If your license is expiring soon or has expired, contact:

**📧 gna.geomatics@gmail.com**

---

## 📂 Repository Contents

- `LicenseValidator.cs` – Source code for the validation class.
- `README.md` – Integration guide for developers.
- `GNA_CommercialLicenseValidator.dll` – Compiled DLL (in Releases).

---

## 📜 License

This software is proprietary and intended for commercial use under license agreement.
Unauthorized redistribution or modification is prohibited.

This software forms part 2 of a two part package. Part 1 is the license code generator. 
Both components are available for commercial use through a 1 year, unlimited use license.

Contact: Julian Gray
gna.geomatics@gmail.com
+4917672997904



