//
//  _MDPAppConfigurationVersionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPAppConfigurationVersionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPAppConfigurationVersionModelAttributes {
	__unsafe_unretained NSString *configuration;
	__unsafe_unretained NSString *configurationHash;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPAppConfigurationVersionModelAttributes;

@interface _MDPAppConfigurationVersionModel : NSManagedObject

@property (nonatomic, strong) NSString* configuration;

//- (BOOL)validateConfiguration:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* configurationHash;

//- (BOOL)validateConfigurationHash:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPAppConfigurationVersionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveConfiguration;
- (void)setPrimitiveConfiguration:(NSString*)value;

- (NSString*)primitiveConfigurationHash;
- (void)setPrimitiveConfigurationHash:(NSString*)value;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

@end
