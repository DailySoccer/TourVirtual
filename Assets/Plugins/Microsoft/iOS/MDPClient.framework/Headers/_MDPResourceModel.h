//
//  _MDPResourceModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPResourceModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPResourceModelAttributes {
	__unsafe_unretained NSString *appId;
	__unsafe_unretained NSString *contentType;
	__unsafe_unretained NSString *file;
	__unsafe_unretained NSString *lastModification;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *major;
	__unsafe_unretained NSString *minor;
} MDPResourceModelAttributes;

@interface _MDPResourceModel : NSManagedObject

@property (nonatomic, strong) NSString* appId;

//- (BOOL)validateAppId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* contentType;

@property (atomic) uint16_t contentTypeValue;
- (uint16_t)contentTypeValue;
- (void)setContentTypeValue:(uint16_t)value_;

//- (BOOL)validateContentType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* file;

//- (BOOL)validateFile:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastModification;

//- (BOOL)validateLastModification:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* major;

@property (atomic) uint64_t majorValue;
- (uint64_t)majorValue;
- (void)setMajorValue:(uint64_t)value_;

//- (BOOL)validateMajor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* minor;

@property (atomic) uint64_t minorValue;
- (uint64_t)minorValue;
- (void)setMinorValue:(uint64_t)value_;

//- (BOOL)validateMinor:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPResourceModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAppId;
- (void)setPrimitiveAppId:(NSString*)value;

- (NSNumber*)primitiveContentType;
- (void)setPrimitiveContentType:(NSNumber*)value;

- (uint16_t)primitiveContentTypeValue;
- (void)setPrimitiveContentTypeValue:(uint16_t)value_;

- (NSData*)primitiveFile;
- (void)setPrimitiveFile:(NSData*)value;

- (NSDate*)primitiveLastModification;
- (void)setPrimitiveLastModification:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMajor;
- (void)setPrimitiveMajor:(NSNumber*)value;

- (uint64_t)primitiveMajorValue;
- (void)setPrimitiveMajorValue:(uint64_t)value_;

- (NSNumber*)primitiveMinor;
- (void)setPrimitiveMinor:(NSNumber*)value;

- (uint64_t)primitiveMinorValue;
- (void)setPrimitiveMinorValue:(uint64_t)value_;

@end
