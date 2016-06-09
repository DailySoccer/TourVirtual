//
//  _MDPConfigurationTrustedClientAppModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPConfigurationTrustedClientAppModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPConfigurationTrustedClientAppModelAttributes {
	__unsafe_unretained NSString *idCLient;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *trustedClientApp;
} MDPConfigurationTrustedClientAppModelAttributes;

@interface _MDPConfigurationTrustedClientAppModel : NSManagedObject

@property (nonatomic, strong) NSString* idCLient;

//- (BOOL)validateIdCLient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* trustedClientApp;

//- (BOOL)validateTrustedClientApp:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPConfigurationTrustedClientAppModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCLient;
- (void)setPrimitiveIdCLient:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTrustedClientApp;
- (void)setPrimitiveTrustedClientApp:(NSString*)value;

@end
