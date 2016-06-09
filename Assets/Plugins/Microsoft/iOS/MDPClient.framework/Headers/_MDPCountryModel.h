//
//  _MDPCountryModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCountryModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCountryModelAttributes {
	__unsafe_unretained NSString *countryCode;
	__unsafe_unretained NSString *descriptionCountry;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPCountryModelAttributes;

@interface _MDPCountryModel : NSManagedObject

@property (nonatomic, strong) NSString* countryCode;

//- (BOOL)validateCountryCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* descriptionCountry;

//- (BOOL)validateDescriptionCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCountryModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCountryCode;
- (void)setPrimitiveCountryCode:(NSString*)value;

- (NSString*)primitiveDescriptionCountry;
- (void)setPrimitiveDescriptionCountry:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

@end
