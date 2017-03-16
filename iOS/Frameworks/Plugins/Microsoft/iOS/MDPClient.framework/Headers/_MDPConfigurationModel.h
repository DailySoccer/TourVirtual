//
//  _MDPConfigurationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPConfigurationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPConfigurationModelAttributes {
	__unsafe_unretained NSString *appConfiguration;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *setting;
} MDPConfigurationModelAttributes;

@interface _MDPConfigurationModel : NSManagedObject

@property (nonatomic, strong) NSString* appConfiguration;

//- (BOOL)validateAppConfiguration:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* setting;

//- (BOOL)validateSetting:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPConfigurationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAppConfiguration;
- (void)setPrimitiveAppConfiguration:(NSString*)value;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveSetting;
- (void)setPrimitiveSetting:(NSString*)value;

@end
